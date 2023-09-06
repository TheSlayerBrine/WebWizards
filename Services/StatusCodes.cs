namespace WebWizards.Services
{
    public enum StatusCodes
    {
        SuccessOperation = 200,
        CreatedInstance = 201,
        NotAllowedError=  405,
        BadRequestError= 400,
        UnauthorizedError= 401 ,
        NotFoundError= 404,
        InternalServerError= 500,
        ExistingInstanceWithSaidDetailsError= 409 ,
        InvalidCredentialError= 401 ,
    }
}
