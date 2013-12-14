using System;
using EquipCheck.Domain;

namespace EquipCheck.Services
{
    /// <summary>
    /// Interface for defining an Equipment Checklist Application User Service.
    /// Design Pattern: Separated Interface - Interface that separates the service 
    /// implementation classes from the IService interface and the Factory class.
    /// </summary>
    public interface IUserSvc : IService
    {
        /// <summary> Method abstraction for storing an EquipCheckAppUser. </summary>
        /// <param name="user"> Specifies the EquipCheckAppUser. </param>
        /// <returns> Returns user if stored successfully. </returns>
        EquipCheckAppUser StoreEquipCheckAppUser(EquipCheckAppUser user);
        
        /// <summary> Method abstraction for getting an EquipCheckAppUser. </summary>
        /// <param name="user"> Specifies the EquipCheckAppUser. </param>
        /// <returns> Returns the GetEquipCheckAppUser found in the database, or null if not found. </returns>
        EquipCheckAppUser GetEquipCheckAppUser(EquipCheckAppUser user);

        EquipCheckAppUser GetLocalUser(EquipCheckAppUser appUser);
    }
}
