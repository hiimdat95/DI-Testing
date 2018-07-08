using DITest.Common;
using DITest.Data.Infrastructure;
using DITest.Data.Repositories;
using DITest.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DITest.Service
{
    public interface ICommonService
    {
        Footer GetFooter();

        IEnumerable<Slide> GetSlides();

        SystemConfig GetSystemConfig(string code);
        List<SystemConfig> GetListSystemConfig();
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private ISystemConfigRepository _systemConfigRepository;
        private IUnitOfWork _unitOfWork;
        private ISlideRepository _slideRepository;

        public CommonService(IFooterRepository footerRepository, ISystemConfigRepository systemConfigRepository, IUnitOfWork unitOfWork, ISlideRepository slideRepository)
        {
            _footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }
        public List<SystemConfig> GetListSystemConfig()
        {
            return _systemConfigRepository.GetAll().ToList();
        }
        public SystemConfig GetSystemConfig(string code)
        {
            return _systemConfigRepository.GetSingleByCondition(x => x.Code == code);
        }
    }
}