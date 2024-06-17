﻿using OticaCrista.Infra.DataBase.Repository.Brand;

namespace OticaCrista.Application.UseCases.Brand
{
    public class DeleteBrandUseCase
    {
        private readonly IBrandRepository _brandRepository;
        public DeleteBrandUseCase(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        public async Task<bool> Execute(int id)
        {
            return await _brandRepository.DeleteBrandAsync(id);
        }
    }
}