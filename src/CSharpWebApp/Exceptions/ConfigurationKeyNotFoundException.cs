namespace CSharpWebApp.Exceptions;

public class ConfigurationKeyNotFoundException(string configKey) : Exception(configKey);
