using Amazon.S3;
using Amazon.S3.Model;
using MvcCoreApiPeliculasAWS7.Models;
using System.Net;

namespace MvcCoreApiPeliculasAWS7.Services
{
    public class ServiceStorageAWS
    {
        private IAmazonS3 client;
        private string BucketName;
        public ServiceStorageAWS(KeysModel keys, IAmazonS3 client)
        {
            this.client = client;
            this.BucketName =
                keys.BucketName;    
        }

        public async Task<bool> UploadFileAsync(string fileName, Stream stream)
        {
            PutObjectRequest request = new PutObjectRequest
            {
                InputStream = stream,
                Key = fileName,
                BucketName = this.BucketName
            };
            PutObjectResponse response =
                await client.PutObjectAsync(request);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
