package Main;
import java.lang.System;
import java.util.ArrayList;

import Matrix.*;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.sql.Date;
import java.text.DecimalFormat;
import java.time.LocalDateTime;


public class Main
{
	public static void main(String[] args) throws InterruptedException
	{
		MatrixIO io = new MatrixIO(); 
				
		int n = io.ReadInt("Enter n: ");
		int m = io.ReadInt("Enter m: ");
		int p = io.ReadInt("Enter p: ");
		
		long startTime = System.nanoTime();
		Matrix matrix = new Matrix(n, m);
		long endTime = System.nanoTime();
		System.out.printf("Creation of matrix one took %f \n", (endTime - startTime) / 1000000000.0);
		
		startTime = System.nanoTime();
		Matrix matrixToAdd = new Matrix(n, m);
		endTime = System.nanoTime();
		System.out.printf("Creation of matrix two  took %f \n", (endTime - startTime) / 1000000000.0);
		
		startTime = System.nanoTime();
		System.out.println("Entering method " + Thread.currentThread().getName());
		matrix.AdditionWithThreads(matrixToAdd, p);
		endTime = System.nanoTime();
		System.out.println("Exited method " + Thread.currentThread().getName());
		
		
		System.out.printf("Elapsed time: %f seconds \n", (endTime - startTime) / 1000000000.0);
		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
		try
		{
			br.readLine();
		}
		catch (Exception e)
		{
			
		}
	}
}
