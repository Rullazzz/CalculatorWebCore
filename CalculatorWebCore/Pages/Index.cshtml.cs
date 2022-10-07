using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CalculatorWebCore.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public string? ResultExpression { get; private set; }

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet(string expression)
		{
			try
			{
				ResultExpression = new DataTable().Compute(expression, null).ToString();
				_logger.Log(LogLevel.Information, "expression = {0}, result = {1}", expression, ResultExpression);
			}
			catch (SyntaxErrorException)
			{
				ResultExpression = "Error";
				_logger.Log(LogLevel.Error, "syntax error");
			}
			catch (Exception)
			{
				ResultExpression = "Error";
				_logger.Log(LogLevel.Error, "unknown error");
			}

		}
	}
}