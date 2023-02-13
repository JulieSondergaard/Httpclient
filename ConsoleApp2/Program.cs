using System.Text.RegularExpressions;


// This class holds a http client, that requests a website and write out the response(body) in the console.
// From a regex method, the body is replaced with a formatted version.
internal class Program
{

	static readonly HttpClient client = new HttpClient();
	static async Task Main()
	{
		
		// In a try/catch block asynchronous network methods is called to handle possible exceptions
		try
		{
			using HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
			response.EnsureSuccessStatusCode();

			string responseBody = await response.Content.ReadAsStringAsync();

			// replacing the response body with a regex formatted value
			responseBody = useRegex(responseBody);

			Console.WriteLine(responseBody);
		}
		catch (HttpRequestException e)
		{
			Console.WriteLine("\nException Caught!");
			Console.WriteLine("Message :{0} ", e.Message);
		}
	}


	// Regex method replacing the originally response body string to a regex formatted string
	public static string useRegex(string text)
	{
		Regex regex = new Regex("\\<[^\\>]*\\>");

		text = regex.Replace(text, String.Empty);

		return text;
	}
}