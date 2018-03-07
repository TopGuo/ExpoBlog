using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExpoBlog.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ExpoBlog {
    public class Program {
        public static void Main (string[] args) {

            BuildWebHost(args).Run();
            // var host = new WebHostBuilder ()
            //     .UseKestrel ()
            //     .UseIISIntegration ()
            //     .UseContentRoot (Directory.GetCurrentDirectory ())
            //     .UseStartup<Startup> ()
            //     .Build ();

            // host.Run ();

            // var db =new BlogContext();
            // var blog=new BlogRoll(){
            //     Id=Guid.NewGuid(),
            //     NickName="xx",

            // };
            // db.BlogRolls.Add(blog);
            // db.SaveChanges();

        }

        public static IWebHost BuildWebHost (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ()
            .Build ();
    }
}