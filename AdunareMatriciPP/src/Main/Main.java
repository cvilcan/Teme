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
				
		int n = 3000;//io.ReadInt("Enter n: ");
		int m = 4000;//io.ReadInt("Enter m: ");
		int p = 4;//io.ReadInt("Enter p: ");
		Matrix matrix = new Matrix(n, m);
		Matrix matrixToAdd = new Matrix(n, m);
		
		long startTime = System.nanoTime();
		java.util.Date date = new java.util.Date();
		System.out.print("Entering method");
		matrix.AdditionWithThreads(matrixToAdd, p);
		System.out.println("Exited method");
		long endTime = System.nanoTime();
		
		System.out.printf("Elapsed time: %f seconds", (endTime - startTime) / 1000000000.0);
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
