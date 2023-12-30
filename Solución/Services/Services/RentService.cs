using Repository.Entities;
using Repository.Repository;
using Services.Base;
using System;

namespace Services.Services
{
    public class RentService : GenericService<RentModel, Rent>
    {
        RentRepository _repository;
        public RentService()
        {
            _repository = new RentRepository();
        }

        public void EndRent(RentModel model)
        {
            _repository.EndRent(model);
        }
    }
}
