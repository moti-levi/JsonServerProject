using JsonServerProject.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JsonServerProject.Api
{
    public class RequestApi
    {
        private string strUrl = String.Format("https://jsonplaceholder.typicode.com/photos");
        public RequestApi()
        {

        }


        #region Get Content
        public async Task<List<DataControllerModel>> GetContent(int from, int itemsPerPage)
        {

            List<DataControllerModel> dataList = null;

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(strUrl);
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                dataList = JsonConvert.DeserializeObject<List<DataControllerModel>>(str);
            }


            if (from + itemsPerPage <= dataList.Count())
                dataList.GetRange(from, itemsPerPage);

            return dataList;
        }

        #endregion


        public async Task<List<DataControllerModel>> GetContent()
        {

            List<DataControllerModel> dataList = null;

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(strUrl);
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                dataList = JsonConvert.DeserializeObject<List<DataControllerModel>>(str);
            }

            return dataList.GetRange(10, 200);

        }
    }
}
