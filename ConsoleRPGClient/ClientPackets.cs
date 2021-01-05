namespace ConsoleRPGClient
{
    public enum ClientPackets
    {
        REGISTRATION_FAILED = 0x00,
        REGISTRATION_SUCCESS = 0x01,
        
        AUTHENTICATION_FAILED = 0x00,
        AUTHENTICATION_SUCCESS = 0x01,
        
        GET_AUTH_VIEW = 0x01,
        AUTHENTICATION_DATA = 0x02,
        REGISTRATION_VIEW = 0x03,
        REGISTRATION_DATA = 0X04,
        REGISTRATION_STATUS = 0x05,
        AUTHENTICATION_STATUS = 0x06
    }
}