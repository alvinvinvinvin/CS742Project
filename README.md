# CS742Project
CS742FinalProject

Using formal method (Object-Z) to create a specification before starting coding.

A software consulting company has several divisions, each division having a separate manager and a set of employees. The company gets projects from its customers and asks the managers to finish those projects. Each manager may then take a part of a project or the whole project and assign employees in his/her division to work on the project. A manager must estimate the number of hours anticipated to complete the portion of the project that he/she is responsible for. At the same time, each employee working on a project must periodically report on the number of hours worked on the project. When the project is finished, the manager compares the estimated number of hours with the actual number of hours spent on the project. All information pertaining to the managers, employees and projects is stored in a company database.

The following assumptions are made to simplify the tasks:

No customer information is stored in the database.

No cost information is included in the current project. That is, there is no need to consider the cost of the incoming projects and also no need to consider the salary of employees.

An employee belongs to exactly one division.

A manager is responsible for exactly one division.

A project may be done by more than one division.

An employee may work on more than one project.

The number of divisions in the company are fixed. Each division has at most one manager. No division is considered to be operational without a manager and at least one employee. In other words, no project can be assigned to a division if there is no manager or no employee.

The following minimal set of functionalities must be implemented:

Hire a manager for a division.

Fire a manager from a division.

Move a manager from one division to another.

Hire an employee. Note that an employee must be hired for a particular division.

Fire an employee.

Move an employee from one division to another division.

Add a new project to the company. Notice that when a project is added, it should be right away assigned to the divisions which are responsible for completing the projects. Subsequently, each manager to which the project is assigned must estimate the number of hours to complete the project.

Assign an employee to a project. Notice that the project must be assigned to the division in which the employee works, before assigning the employee.

De-assign an employee from a project.

Complete a project. This is more like a declaration of the completion of the project. At this time, a report must be generated that compares the actual number of hours spent on a project with those that are estimated initially.

Report the number of hours spent by an employee on a given project. There is no need to consider whether this is a daily, weekly or monthly report.

Additional functionalities may be included in order to support the minimal set of functionalities listed above.

 

Write the Object-Z specification for the above problem. Implement and demonstrate this product.
