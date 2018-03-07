using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ExpoBlog.Models {
    public static class SampleData {
        public static async Task InitializeYuukoBlogAsync (IServiceProvider serviceProvider) {
            var db = serviceProvider.GetService<BlogContext> ();

            await db.Database.EnsureCreatedAsync ();
        }

        public static bool InitializeYuukoBlog (IServiceProvider serviceProvider) {
            var db = serviceProvider.GetService<BlogContext> ();

            return db.Database.EnsureCreated ();
        }
    }
}