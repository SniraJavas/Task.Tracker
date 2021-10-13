using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeBelieveIT.Task.Tracker.Models;

namespace WeBelieveIT.Task.Tracker
{
    public class Startup
    {
        public ApiContext Context { set; get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("TaskTracker"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeBelieveIT.Task.Tracker", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeBelieveIT.Task.Tracker v1"));
            }
           

            //var context = app.ApplicationServices.GetService<ApiContext>();
            using (var ServiceScope = app.ApplicationServices.CreateScope()) 
            {
                Context = ServiceScope.ServiceProvider.GetService<ApiContext>();
                AddTestData(Context);
            }
               

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddTestData(ApiContext context)
        {
            var jobType1 = new JobType()
            {
                Id = 1,
                Name = "Developer",
            };

            var jobType2 = new JobType()
            {
                Id = 2,
                Name = "Designer",
            };

            var jobType3 = new JobType()
            {
                Id = 3,
                Name = "HR",
            };

            var jobType4 = new JobType()
            {
                Id = 4,
                Name = "Accountant",
            };

            var jobType5 = new JobType()
            {
                Id = 5,
                Name = "General",
            };

            context.jobTypes.Add(jobType1);
            context.jobTypes.Add(jobType2);
            context.jobTypes.Add(jobType3);
            context.jobTypes.Add(jobType4);
            context.jobTypes.Add(jobType5);


            var progress1 = new Progress()
            {
                Id = 1,
                Name = "Backlog",
                
            };

            var progress2 = new Progress()
            {
                Id = 2,
                Name = "To-do",

            };

            var progress3 = new Progress()
            {
                Id = 3,
                Name = "Progress",

            };

            var progress4 = new Progress()
            {
                Id = 4,
                Name = "Review",

            };

            var progress5 = new Progress()
            {
                Id = 5,
                Name = "Done",

            };

            context.Progress.Add(progress1);
            context.Progress.Add(progress2);
            context.Progress.Add(progress3);
            context.Progress.Add(progress4);
            context.Progress.Add(progress5);

            var user1 = new User()
            {
                Id = "xio-id-8982",
                FirstName = "John",
                LastName = "Doe",
                Email = "Johnie@tracker.it",
                TittleId = 2,
            };

            var user2 = new User()
            {
                Id = "xio-iyu-552",
                FirstName = "Chris",
                LastName = "Black",
                Email = "Chris@tracker.it",
                TittleId = 3,
            };

            var user3 = new User()
            {
                Id = "xio-qwq-3282",
                FirstName = "Maria",
                LastName = "Denver",
                Email = "Maria@tracker.it",
                TittleId = 1,
            };

            var user4 = new User()
            {
                Id = "xio-tyu-u22",
                FirstName = "Berlin",
                LastName = "Geek",
                Email = "Berlie@tracker.it",
                TittleId = 4,
            };

            var user5 = new User()
            {
                Id = "xio-doa-1282",
                FirstName = "Sinikiwe",
                LastName = "Jumba",
                Email = "Snikey@tracker.it",
                TittleId = 5,
            };

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Users.Add(user5);

            var job1 = new Job()
            {
                Id = "qw-wr-q-1123",
                Name = "design spint",
                Description = "add expected time and break down tasks into smaller task for Junior devs",
                Estimation = 48,
                ProgressId = 1,
                Remaining = 48,
                UserId = "xio-iyu-552"
            };

            var job2 = new Job()
            {
                Id = "tydgr-q-8823",
                Name = "draft bonus",
                Description = "undergo the latest employee salary increases and update payroll for Bonuses",
                Estimation = 68,
                ProgressId = 1,
                Remaining = 68,
                UserId = "xio-tyu-u22"
            };

            var job3 = new Job()
            {
                Id = "qw-qwer-0023",
                Name = "Maintanance",
                Description = "Contact our service provider for 5G upgrade and order more Machines to increase our work stations",
                Estimation = 68,
                ProgressId = 1,
                Remaining = 68,
                UserId = "xio-doa-1282"
            };

            context.Jobs.Add(job1);
            context.Jobs.Add(job2);
            context.Jobs.Add(job3);
            context.SaveChanges();
        }
    }
}
