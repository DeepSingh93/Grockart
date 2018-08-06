namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public interface IUserProfile
    {
        void SetSalt(string Salt);
        string GetSalt();
        void SetRoleType(string RoleType);
        string GetRoleType();
        void SetToken(string Token);
        string GetToken();
        void SetHashedPassword(string HashedPassword);
        string GetHashedPassword();
        void SetPassword(string Password);
        string GetPassword();
        string GetFirstName();
        void SetFirstName(string value);
        string GetLastName();
        void SetLastName(string value);
        string GetEmail();
        void SetEmail(string value);
        bool GetIsAdmin();
        void SetIsAdmin(bool value);
        double GetAmountOwe();
        void SetAmountOwe(double value);
        double GetAmountPaid();
        void SetAmountPaid(double value);
        void CheckNulls(string Input, object InputType);
    }
}