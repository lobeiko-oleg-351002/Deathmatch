using AutoMapper;
using BLL.Exceptions;
using BLL.Services.Interface;
using DAL.Exceptions;
using DAL.Repositories.Interface;
using Models;
using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services
{
    public class UserService : Service<User, UserViewModel, UserCreateModel>, IUserService
    {
        private readonly IUserValidationService _userValidationService;
        //private readonly ICacheService _cacheService;
        public UserService(IUserRepository UserRepository, IUserValidationService userValidationService, IMapper mapper) 
            : base(UserRepository, mapper)
        {
            _userValidationService = userValidationService;
           // _cacheService = cacheService;
        }

        public async Task<UserViewModel> GetByNameAndPassword(string name, string password)
        {
            _userValidationService.ValidateNameAndPassword(name, password);
            try
            {
                var entity = await ((IUserRepository)_repository).GetByNameAndPassword(name, password);
                return _mapper.Map<UserViewModel>(entity);
            }
            catch (ItemNotFoundException)
            {
                throw new UserNotFoundException();
            }
        }

        public override async Task Create(UserCreateModel entity)
        {
            _userValidationService.ValidateNewUser(_mapper.Map<UserCreateModel>(entity));
            await base.Create(entity);
           // _cacheService.Set(GetKey(result.Id.ToString()), result);
        }

        public override async Task Update(UserCreateModel entity)
        {
            _userValidationService.ValidateNewUser(_mapper.Map<UserCreateModel>(entity));
           await base.Update(entity);
        }

        //public override async Task<UserViewModel> Get(Guid id)
        //{
        //    UserViewModel user = _cacheService.Get<UserViewModel>(GetKey(id.ToString()));
        //    if (user == null)
        //    {
        //        user = await base.Get(id);
        //        _cacheService.Set(GetKey(user.Id.ToString()), user);
        //    }
        //    return user;
        //}
    }
}
