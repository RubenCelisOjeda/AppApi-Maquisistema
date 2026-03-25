using ApiProduct.Domain.Entities;
using ApiProduct.Domain.Repository;
using ApiProduct.Shared.Configuration.Connection;
using Dapper;
using System.Data;

namespace ApiProduct.Infraestructura.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region [Properties]

        private readonly IConnectionFactory _configuration;

        #endregion

        #region [Constructor]

        public ProductRepository(IConnectionFactory configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region [Methods]

        public async Task<Product> GetById(int id)
        {
            using (var connection = _configuration.GetConnectionProduct)
            {
                #region [Query]
                const string procedure = @"SELECT [Id], [UserName], [Password], [Email], [DateCreated], [DateModify], [Status]
                                           FROM sis.Usuarios
                                           WHERE Id = @pIdUser";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    pIdUser = id
                });
                #endregion

                #region [Execute]
                var response = await connection.QueryFirstOrDefaultAsync<Product>(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<int> AddProduct(Product request)
        {
            using (var connection = _configuration.GetConnectionProduct)
            {
                #region [Query]
                const string procedure = @"INSERT INTO sis.Usuarios (UserName, Password, Email, DateCreated, DateModify, Status)
                                           VALUES (@pUserName, @pPassword, @pEmail, GETDATE(), NULL, @pStatus);
                                           SELECT CAST(SCOPE_IDENTITY() AS INT);";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    //pUserName = request.UserName,
                    //pPassword = request.Password,
                    //pEmail = request.Email,
                    //pStatus = request.Status
                });
                #endregion

                #region [Execute]
                var response = await connection.ExecuteScalarAsync<int>(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<int> UpdateProduct(Product request)
        {
            using (var connection = _configuration.GetConnectionProduct)
            {
                #region [Query]
                const string procedure = @"UPDATE sis.Usuarios SET UserName = @pUserName,
                                                                   Password = @pPassword,
                                                                   DateModify = @pDateModify,
                                                                   Status = @pStatus

                                                               WHERE Id = @pIdUser";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    //pIdUser = request.IdUser,
                    //pUserName = request.UserName,
                    //pPassword = request.Password,
                    //pDateModify = request.DateModify,
                    //pEmail = request.Email,
                    //pStatus = request.Status
                });
                #endregion

                #region [Execute]
                var response = await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        #endregion
    }
}
