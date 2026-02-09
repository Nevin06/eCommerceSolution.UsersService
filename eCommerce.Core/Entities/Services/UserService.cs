using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities.RepositoryContracts;
using eCommerce.Core.Entities.ServiceContracts;

namespace eCommerce.Core.Entities.Services;

public class UserService : IUserService
{
    private readonly IUsersRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUsersRepository usersRepository, IMapper mapper)
    {
        _userRepository = usersRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user == null)
        {
            return null;
        }
        else
        {
            //return new AuthenticationResponse(user.UserID, user.Email, user.PersonName,
            //    Enum.TryParse<GenderOptions>(user.Gender, out var gender) ? gender : GenderOptions.Others,
            //    "token", Success : true);
            // Using AutoMapper to map ApplicationUser to AuthenticationResponse(19)
            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token"};
        }
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        ApplicationUser? registeredUser = await _userRepository.AddUser(
        //    new ApplicationUser
        //{
        //    Email = registerRequest.Email,
        //    Password = registerRequest.Password,
        //    PersonName = registerRequest.PersonName,
        //    Gender = registerRequest.Gender.ToString()
        //}
        _mapper.Map<ApplicationUser>(registerRequest)
            );

        if (registeredUser == null)
        {
            return null;
        }
        else
        {
            //return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, 
            //    registeredUser.PersonName, 
            //    Enum.TryParse<GenderOptions>(registeredUser.Gender, out var gender) ? gender : GenderOptions.Others, 
            //    "token", Success : true);
            // Using AutoMapper to map ApplicationUser to AuthenticationResponse(19)
            return _mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token"};
        }
    }
}
