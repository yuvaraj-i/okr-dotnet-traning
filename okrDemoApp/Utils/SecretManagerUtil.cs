using System;
using Amazon;
using Amazon.Runtime.Internal.Util;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Extensions.Caching;
using Amazon.SecretsManager.Model;

namespace okrDemoApp.Utils
{
	public class SecretManagerUtil
	{
        public static SecretsManagerCache? cache;

        public SecretManagerUtil()
		{

		}

        public static async Task<string> GetSecret()
        {
            string secretName = "dot-net/tranning";

            //var config = new AmazonSecretsManagerConfig { RegionEndpoint = RegionEndpoint.USEast1 };
            //IAmazonSecretsManager client = new AmazonSecretsManagerClient("ASIA4Y2YIVR4TMJK6RHV", "EeJEoyOgCuEoskkRfCnQoE1C5/8FlrXOapxuR9Hw", "IQoJb3JpZ2luX2VjEFYaCXVzLWVhc3QtMSJGMEQCICxoHLMMUfuHLpHbrAh+uKFM5RYEYh43d4lbaQDLZLINAiAkxfzUpqcSeWO5zC4TOdGfDBMjXUa6/Bana9p37UnrmiqSAwjP//////////8BEAIaDDg3Nzk2OTA1ODkzNyIM0fUDk2kT2g/QW2yeKuYC4opgOCZ51H0+VkqeJLQBGSz5ZMfJEdvJGXXFPSiNEbSnWUGGAADkvmkti7Kc/5wH1TQmoYGjBn9n/Y4yAXg/P1D/p5pVYZ0VBSHcfCkFhNPXMIhiy3oPUnrT597Q2cE4EmRnKpv09fQt9DjuViaF75nQGTVZHNam3v0PuJsz4Z698w6YFCkICHJTjA2QgXKurSaLjyyAK4CHfJST4EKdbBBkiKqmTNJDg5JteSuu3SD2KaOCJPtEdusrYDdxE6iMm8KVn1MKBq4AbHoJVJ+qKHcxk3gjVdDmBbf7UyXUCmiEo3Bkwavw+7/EgdbIanBi2xqiy+kxk52Fu/asjp2b0jcgk6XOusFfNIGgalZhaZuiLiQ2CTTtTtQpIFP5KjbES0FXWFzmk/YXSHZHaryUpkSeHprtI/dyFwt2NlWcjBQFaQKB843zWaqQkQdHd8xN6qOebvxHBinlDi4YrAqNrQr/2JzS0zDnou2eBjqnAfTr07zLOgSF7gmIJr+WHUuLvBenAm78iaES00uouzu4hlquLQy6scOLnkAU3xReWx19Nqle4Q1OgqNF/ZD3JdRkeCYur+qprK9aSDqzIDoJ7/1zR5TfEo42tWbljxzjdrSs6Fmshsb3LCbiGN+kZJhU6Kq3jtHKGLF9kGL3Zx6s3iIkY9Y0x0TFDqdYQqBf/g4KneZSUeqy6FHS+o7bM1oc4UG35V10", config);

            //GetSecretValueRequest request = new GetSecretValueRequest
            //{
            //    SecretId = secretName,
            //    VersionStage = "AWSCURRENT", 
            //};

            //GetSecretValueResponse response;

            try
            {
                //response = await client.GetSecretValueAsync(request);

                //Console.WriteLine(response.SecretString);
            }
            catch (Exception e)
            {
                throw e;
            }

            return "";
        }
    }
}

