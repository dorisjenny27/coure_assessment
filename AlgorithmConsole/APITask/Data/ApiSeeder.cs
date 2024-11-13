using APITask.Models.Entites;
using Newtonsoft.Json;

namespace APITask.Data
{
    public class ApiSeeder
    {
        public static async Task SeedData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            await Seeder(serviceScope.ServiceProvider.GetService<ApiContext>());
        }
        private async static Task Seeder(ApiContext context)
        {
            try
            {
                var baseDir = Directory.GetCurrentDirectory();
                await context.Database.EnsureCreatedAsync();

                if (!context.Countries.Any())
                {
                    var path = File.ReadAllText(FilePath(baseDir, "StaticsFiles/Json/Data.json"));

                    var countries = JsonConvert.DeserializeObject<List<Country>>(path);

                    await context.AddRangeAsync(countries);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        static string FilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}