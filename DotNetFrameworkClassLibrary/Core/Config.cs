using System.Configuration;

namespace DotNetFrameworkClassLibrary.Core
{
	class Config
	{
		public string GetBaseUrl()
		{
			return ConfigurationManager.AppSettings["BaseUrl"];
		}
	}
}
