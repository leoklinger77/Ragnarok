using Ragnarok.Models;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using System;

namespace Ragnarok.Services.WebService
{
    public class WSCorreiosAPI
    {
        private readonly ICityRepository _cityRepository;

        public WSCorreiosAPI(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public AddressWSCorreiosViewModel SearchByZipCode(string zipCode)
        {
            
            try
            {
                var ws =  new WSCorreios.AtendeClienteClient().consultaCEPAsync(zipCode);

                string cidade = ws.Result.@return.cidade;
                string siglaUf = ws.Result.@return.uf;

                City city = _cityRepository.FindByNameAndState(cidade, siglaUf);
                AddressWSCorreiosViewModel model = new AddressWSCorreiosViewModel();
                model.city = city.Name;
                model.CityId = city.Id;
                model.state = city.State.Name;
                model.StateId = city.State.Id;
                model.street = ws.Result.@return.end;
                model.Neighborhood = ws.Result.@return.bairro;

                return model;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
