using System;
using static System.Math;

// Class which implements the Jacobi eigenvalue algorithm for matrix diag.
public class jacobi_diag {

	public static void cyclic(matrix A, matrix V) {
		if(V.size1 != V.size2 || A.size1 != A.size2) {
			throw new ArgumentException("Only square matrices as input.");
		}

		int n = A.size1;
		bool changed;
		
		do {
			changed = false;
			/* All rows */
			for(int p = 0; p < n-1; p++) { 
			/* All elements in row except the p'th */
			for(int q = p+1; q < n; q++) { 
				/* Get the entries subject to change */
				double apq = matrix.get(A, p, q);
				double app = matrix.get(A, p, p);
				double aqq = matrix.get(A, q, q);
				
				/* Calculate theta so pq entry will be zero */
				double theta = 0.5 * Atan2(2*apq, aqq-app);
				double c = Cos(theta), s = Sin(theta);
				
				/* Calculate new [p,p] and [q,q] entries */
				double new_app = c*c*app - 2*s*c*apq + s*s*aqq;
				double new_aqq = s*s*app + 2*s*c*apq + c*c*aqq;

				/* If changed then diagonal elements are 
				 * not stable yet.. */
				if(new_app != app || new_aqq != aqq) {
					changed = true;
					
					/* Do Jacobi rotation  */
					timesJ(A, p, q, theta);
					Jtimes(A, p, q, -theta);
					timesJ(V, p, q, theta);
				}
			}
			}
		
		}
		while(changed);

	}	

	// Implent a function that multiplies the matrix A and Jacobi matrix. 
	public static void timesJ(matrix A, int p, int q, double theta) {
		double c = Cos(theta), s = Sin(theta);
	       	for(int i = 0; i < A.size1; i++) {
			double aip = A[i,p], aiq = A[i,q];
			A[i,p] = c*aip - s*aiq;
			A[i,q] = s*aip + c*aiq;
	       }	       
	}
	// Implement a function that multiplies the Jacobi matrix and matrix A.
	public static void Jtimes(matrix A, int p, int q, double theta) {
		double c = Cos(theta), s = Sin(theta);
		for(int j = 0; j < A.size1; j++) {
			double apj = A[p,j], aqj = A[q,j];
			A[p,j] = c*apj + s*aqj;
			A[q,j] = -s*apj + c*aqj;
		}
	}


}
