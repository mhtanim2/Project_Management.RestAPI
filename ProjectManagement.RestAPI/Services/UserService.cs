using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.CodeAnalysis;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DTOs;
using ProjectManagement.RestAPI.Entities;
using ProjectManagement.RestAPI.Exceptions;
using ProjectManagement.RestAPI.Repositories;
using ProjectManagement.RestAPI.Services.Interfaces;
using ProjectManagement.RestAPI.Validation.UserValidation;

namespace ProjectManagement.RestAPI.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UserCreateDto> _createValidator;
    private readonly IValidator<UserUpdateDto> _updateValidator;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
    IUserRepository userRepository,
    IMapper mapper,
    IValidator<UserCreateDto> createValidator,
    IValidator<UserUpdateDto> updateValidator,
    IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> CreateAsync(UserCreateDto dto)
    {
        var validationResult = await _createValidator.ValidateAsync(dto);
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid User Type", validationResult);

        var user = _mapper.Map<User>(dto);

        await _userRepository.CreateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return user.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _userRepository.GetByIdAsync(id);
        if (existing == null)
            throw new NotFoundException($"User with id {id} not found.");

        await _userRepository.DeleteAsync(existing);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<ICollection<UserReadDto>> GetAllAsync()
    {
        var entities = await _userRepository.GetAsync();
        
        return _mapper.Map<ICollection<UserReadDto>>(entities);
    }

    public async Task<UserReadDto?> GetByIdAsync(int id)
    {
        var entity = await _userRepository.GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<UserReadDto>(entity);
    }

    public async Task UpdateAsync(int id, UserUpdateDto dto)
    {
        
        var existing = await _userRepository.GetByIdAsync(id);
        if (existing == null)
            throw new NotFoundException($"User with id {id} not found.");

        _mapper.Map(dto, existing);

        await _userRepository.UpdateAsync(existing);
        await _unitOfWork.SaveChangesAsync();
    }

}