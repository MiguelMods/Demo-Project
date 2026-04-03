using demo.proyect.application.Repository;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;

namespace demo.proyect_persistance.Repository;

public class EmployeeRepository(DemoProjectApplicationContext demoProjectApplicationContext) : BaseDefaultRepository<EmployeeEntity>(demoProjectApplicationContext), IEmployeeRepository
{
}
