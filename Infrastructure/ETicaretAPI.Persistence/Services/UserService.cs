﻿using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Helpers;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = model.NameSurname,
                UserName = model.Username,
                Email = model.Email,
            }, model.Password);

            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "User successfully created.";
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message = $"{error.Code} - {error.Description}\n";
                }
            }

            return response;
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new NotFoundUserException();
            }
        }

        public async Task PasswordUpdateAsync(string userId, string resetToken, string newPassword)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                }
                else
                {
                    throw new PasswordChangeFailedException();
                }
            }
        }

        public async Task<List<ListUser>> GetAllUsersAsync(int page, int size)
        {
            var users = await _userManager.Users.Skip(page * size).Take(size).ToListAsync();

            return users.Select(user => new ListUser
            {
                Id = user.Id,
                UserName = user.UserName,
                NameSurname = user.NameSurname,
                Email = user.Email,
                TwoFactorEnabled = user.TwoFactorEnabled,
            }).ToList();
        }

        public async Task AssignRoleToUserAsync(string userId, string[] roles)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var appRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, roles);

                await _userManager.AddToRolesAsync(user, appRoles);
            }
        }

        public async Task<string[]> GetRolesToUser(string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }

        public int TotalUsersCount => _userManager.Users.Count();
    }
}
