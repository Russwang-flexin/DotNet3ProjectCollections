using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Frame.EFCore.Interfaces;
using Frame.EFCore.DbFile;
using Frame.EFCore.Repositories;
using Frame.EFCore.Resources.OrderByMapping;
using Frame.EFCore.Resources.Validator;
using Frame.EFCore.Resources.ViewModel;
using Frame.EFCore.Services.FilterVerification;
using Frame.EFCore.Services.OrderBys;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Apitesttest
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
            services.AddControllers();
            services.AddMvc(options =>
            {
                options.ReturnHttpNotAcceptable = true;
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            }).AddXmlSerializerFormatters();
            //services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SwaggerApiTest", Version = "v1" }));

            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });
            services.AddMvc(options =>
            {
                options.ReturnHttpNotAcceptable = true;
                //支持XML 媒体格式数据
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            }).AddNewtonsoftJson(options =>
            {
                //序列化首字母小写
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }).AddXmlSerializerFormatters()
             .AddFluentValidation(); //添加Fluent验证

            services.AddDbContext<ZfsDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlite(connectionString);
            });
            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //    options.HttpsPort = 5001;
            //});
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
            });

            //添加实体映射
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //添加业务接口
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<ILoginLogRepository, LoginlogRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupFuncRepository, GroupFuncRepository>();
            services.AddScoped<IGroupUserRepository, GroupUserRepository>();
            services.AddScoped<IDictionaryTypeRepository, DictionaryTypeRepository>();
            services.AddScoped<IDictionaryRepository, DictionaryRepository>();
            services.AddScoped<IAuthorithitemRepository, AuthorithitemRepository>();
            services.AddScoped<IUnitDbWork, UnitDbWork>();

            //添加验证器
            services.AddTransient<IValidator<UserViewModel>, UserViewModelValidator>();
            services.AddTransient<IValidator<UserAddViewModel>, UserAddOrUpdateResourceValidator<UserAddViewModel>>();
            services.AddTransient<IValidator<UserUpdateViewModel>, UserAddOrUpdateResourceValidator<UserAddOrUpdateViewModel>>();
            services.AddTransient<IValidator<DictionariesViewModel>, DictionariesValidator>();

            //MapContainer
            var propertyMappingContainer = new PropertyMappingContainer();
            propertyMappingContainer.Register<UserPropertyMapping>();
            propertyMappingContainer.Register<DictPropertyMapping>();
            propertyMappingContainer.Register<GroupPropertyMappting>();
            propertyMappingContainer.Register<MenuPropertyMapping>();
            services.AddSingleton<IPropertyMappingContainer>(propertyMappingContainer);

            services.AddTransient<ITypeHelperService, TypeHelperService>();

            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments("./docs/zfsApi.xml");
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ZFS Service API",
                    Version = "v1",
                    Description = "Sample Service for Professional C#7",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "trace gg",
                        //Url = new Uri("http://www.cnblogs.com/zh7791"),
                    },
                });

            });
            //services.AddMvc(options => { options.EnableEndpointRouting = false; });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(op => 
            {
                op.SwaggerEndpoint("/swagger/v1/swagger.json", "SwaggerApiTest v1");
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
