import java.util.ArrayList;
import java.util.HashMap;
import java.util.Random;
import java.util.TreeMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class Main {

    public static void main(String[] args) {
        Tester t = new Tester();
        //t.Test();

        Random rng = new Random();
        ArrayList<Integer> arrayList = new ArrayList<>();
        for (int i = 0; i < 10000; i++)
            arrayList.add(rng.nextInt());

        TreeMap<Integer, Element> sumList = new TreeMap<Integer, Element>();
        ExecutorService es = Executors.newFixedThreadPool(arrayList.size() / 2 + arrayList.size() % 2);
        for (int i = 0; i < arrayList.size() / 2 + arrayList.size() % 2; i++)
            sumList.put(i, new Element());
        long starTime = System.nanoTime();
        for (int i = 0; i < arrayList.size() / 2 + arrayList.size() % 2; i++)
            es.execute(new AdditionThread(arrayList, i * 2, sumList));
        long endTime = System.nanoTime();
        System.out.printf("Elapsed time: %f", (endTime - starTime) / 1000000000.0);

        starTime = System.nanoTime();
        long q = 0;
        for (int i = 0; i < 10000; i++)
            q += arrayList.get(i);
        endTime = System.nanoTime();
        System.out.printf("Elapsed time: %f", (endTime - starTime) / 1000000000.0);

        es.shutdown();
        try {
            es.awaitTermination(Long.MAX_VALUE, TimeUnit.NANOSECONDS);
        } catch (InterruptedException e) {
        }

        System.out.println(sumList.get(0).value);
    }
}
