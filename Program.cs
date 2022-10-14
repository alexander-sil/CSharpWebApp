using System.Text.RegularExpressions;

namespace CSharpWebApp
{
    class Program
    {
        private static HttpClient _httpSingletonService = new HttpClient();

        private static List<string> _urls = FillEntries().ToList();

        private static List<Task<string>> _httpTasks = new List<Task<string>>();

        static IEnumerable<string> FillEntries()
        {
            for (int i = 4; i <= 13; i++)
            {
                yield return $"https://jsonplaceholder.typicode.com/posts/{i}";
            }
        }

        static async Task<string> HttpGet(string address)
        {
            string response = Regex.Replace((await (await _httpSingletonService.GetAsync(address)).Content.ReadAsStringAsync()), "\\ \\ \".*\": |{|}|\"|,", String.Empty);

            return response;
        }

        static async Task Main(string[] args)
        {
            for (int i = 0; i < _urls.Count; i++)
            {
                _httpTasks.Add(HttpGet(_urls[i]));
            }

            await Task.WhenAll(_httpTasks);

            for (int i = 0; i < _httpTasks.Count; i++)
            {
                File.AppendAllText("result.txt", _httpTasks[i].Result);
            }

            Console.WriteLine("Исполнение завершено.");
        }
    }
}

