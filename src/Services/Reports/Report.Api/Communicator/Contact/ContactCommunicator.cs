using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Report.Api.Communicator.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.Api.Communicator.Contact
{
    public class ContactCommunicator : IContactCommunicator
    {
        private static string _baseUrl;

        public ContactCommunicator(IConfiguration configuration)
        {
            _baseUrl = configuration["ContactBaseUrl"];
        }

        public async Task<int> GetInfoByLocation(string location)
        {
            IRestClientHelper _restClientHelper = new RestClientHelper();
            var result = await _restClientHelper.GetAsync(_baseUrl + "/cargoCommission/getCargoCommission");

            return JsonConvert.DeserializeObject<ResponseBase<List<GetCargoCommissionResponse>>>(result);
        }
    }
}
