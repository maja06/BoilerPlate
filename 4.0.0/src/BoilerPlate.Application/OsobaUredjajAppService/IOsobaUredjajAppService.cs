using System.Collections.Generic;
using Abp.Application.Services;
using BoilerPlate.Models;

namespace BoilerPlate.OsobaUredjajAppService
{
    public interface IOsobaUredjajAppService : IApplicationService
    {
        void AddKoriscenje(int uId, int oId);
        List<OsobaUredjaj> SvePoUredjaju(int id);
        void EndKoriscenje(int id);

    }
}
