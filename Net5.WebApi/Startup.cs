using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Net5.WenApi.Ultility.Automapper;
using Net5.WenApi.Ultility.DESEncrypt;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models.Enums;

namespace Net5.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
           {
               options.AddPolicy("default", policy =>
                       {
                           policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();

                       });
           });

            services.AddControllers();

            //�滻Ĭ��IOC����
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Net5.WebApi", Version = "v1" });

                #region ʹ��JWT��Ȩ���
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                                          {
                                            {
                                              new OpenApiSecurityScheme
                                              {
                                                Reference=new OpenApiReference
                                                {
                                                  Type=ReferenceType.SecurityScheme,
                                                  Id="Bearer"
                                                }
                                              },
                                              new string[] {}
                                            }
                                          });

                //��ʾע��
                string dir = Path.GetDirectoryName(typeof(Program).Assembly.Location);  //Ӧ�ó����Ŀ¼
                string xmlpath = Path.Combine(dir, "Net5.WebApi.xml");             //����xml·��
                c.IncludeXmlComments(xmlpath);
                #endregion
            });

            #region sqlsugar.Ico
            services.AddSqlSugar(
            new List<IocConfig> {
                                new IocConfig()
                                    {
                                        ConfigId = "basicinfo",
                                        ConnectionString = DESEncrypt.JieMiStr_Con(this.Configuration.GetSection("ConnectionStrings")["MysqlConn_BasicInfo"]),
                                        DbType = IocDbType.MySql,
                                        IsAutoCloseConnection = true//�Զ��ͷ�
                                    },
                                new IocConfig()
                                    {
                                        ConfigId = "mh_cms",
                                        ConnectionString = DESEncrypt.JieMiStr_Con(this.Configuration.GetSection("ConnectionStrings")["MysqlConn_CMS"]),
                                        DbType = IocDbType.MySql,
                                        IsAutoCloseConnection = true//�Զ��ͷ�
                                    },
                                new IocConfig()
                                    {
                                        ConfigId = "sys_config",
                                        ConnectionString = DESEncrypt.JieMiStr_Con(this.Configuration.GetSection("ConnectionStrings")["MysqlConn_sys_config"]),
                                        DbType = IocDbType.MySql,
                                        IsAutoCloseConnection = true//�Զ��ͷ�
                                    }
                                }
            );

            string conn = DESEncrypt.JieMiStr_Con(this.Configuration.GetSection("ConnectionStrings")["MysqlConn_HealthInfo"]);
            for (int i = 2015; i <= DateTime.Now.Year; i++)
            {
                services.AddSqlSugar(new IocConfig()
                {
                    ConfigId = "health_info" + i,
                    ConnectionString = conn.Replace("health_info", "health_info" + i),
                    DbType = IocDbType.MySql,
                    IsAutoCloseConnection = true//�Զ��ͷ�
                });
            }
            #endregion

            #region JWT��Ȩ
            services.AddCustomJWT();
            #endregion

            #region AutoMapper
            services.AddAutoMapper(typeof(CustomAutoMapperProfile));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net5.WebApi v1"));
            }
            app.UseCors("default");

            app.UseRouting();

            //��Ȩ
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Autofac ע��
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var IService = Assembly.Load("WebApi.IService");
            var Service = Assembly.Load("WebApi.Service");
            builder.RegisterAssemblyTypes(IService, Service)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().PropertiesAutowired();

            var IRepository = Assembly.Load("WebApi.IRepository");
            var Repository = Assembly.Load("WebApi.Repository");
            builder.RegisterAssemblyTypes(IRepository, Repository)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().PropertiesAutowired();

            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
                           .Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
            builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();
        }
    }
    static class ICOExtend
    {
        public static IServiceCollection AddCustomJWT(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VF")),
                        ValidateIssuer = true,
                        ValidIssuer = "http://localhost:6060",
                        ValidateAudience = true,
                        ValidAudience = "http://localhost:55405",
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(60)    //����ʱ��
                    };
                });

            return services;
        }
    }
}
