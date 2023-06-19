This folder contains my solutions to the exam project for the course **ppnm**. The solution is *cubature.cs*, which implements the examination problem. Additionally are *Out.txt* which assesses the implementation on different integrals. 

Student number: 2021092**60**

Therefore my exam project is: **8** = 60 % 26: 

#Adaptive integrator
-------------------
Implement a two-dimensional integrator for integrals in the form

![name](2dintegral.png)

which applies your favourite adaptive one-dimensional integrator along each of the two dimensions. The signature might be something like

static double integ2D(

	Func<double,double,double> f,

	double a, double b,

	Func<double,double> d,

	Func<double,double> u,

	double acc, double eps)

-------------------

#Description of solution
-------------------
The two dimensionel problem can be, alike the one dimensionel in the homeworks, be subdivided. Each of these subdivision can be likewise subdiveded, in which case the resulting integrals are one-dimensional. Therefore I have utilized a motified version of the homeworks quadrature.
Furthermore is used both the trapezium- and rectangle-rule with the purpose of error-estimation. Finally this routine can be cast recursively depending on the wished precision. If the precision goals are not met the routine will adaptively refine the subintervals. 

**cubature.cs** is used by the *integ2D* method, which takes the function, bounds, errors and optional parameters *f2* and *f3*. These are solely for recursion. The *integ2D* method uses a private method, *integ1D*, which is a modified version of the quadrature from the homeworks. This method simply fixes a x-value such that a 1D-integral can be estimated.






