using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.SampleCode;

public class LoggingExamples
{
    private AmazonConnection _amazonConnection;
    public LoggingExamples(IConfigurationRoot config)
    {
        var factory = LoggerFactory.Create(builder => builder.AddConsole());
        
        _amazonConnection = new AmazonConnection(new AmazonCredential()
        {
            //AccessKey = config.GetSection("FikaAmazonAPI:AccessKey").Value,
            //SecretKey = config.GetSection("FikaAmazonAPI:SecretKey").Value,
            //RoleArn = config.GetSection("FikaAmazonAPI:RoleArn").Value,
            ClientId = config.Required("FikaAmazonAPI:ClientId"),
            ClientSecret = config.Required("FikaAmazonAPI:ClientSecret"),
            RefreshToken = config.Required("FikaAmazonAPI:RefreshToken"),
            MarketPlaceID = config.Required("FikaAmazonAPI:MarketPlaceID"),
            SellerID = config.Required("FikaAmazonAPI:SellerId"),
            IsDebugMode = true,
            Environment = Constants.Environments.Sandbox
        }, loggerFactory: factory);
    }
    
    public async Task ConsoleLoggerExample()
    {
        var listingItemExample = new ListingsItemsSample(_amazonConnection);
        await listingItemExample.SetListingsItemAttribute("test");
    }
}