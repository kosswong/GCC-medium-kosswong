import java.io.*;
import java.util.*;
import java.util.stream.Stream;

class Solution {

    // You may change this function parameters
    static int calculateMinimumSession(int numOfBankers, int numOfParticipants, int[][] bankersPreferences, int[][] participantsPreferences) {
        // Participant's code will go here
        return -1;
    }

    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) throws IOException {
        // Sample input:
        // 3 1,1,1&2
        // 3 3&2,1,1
        String[] firstLine = scanner.nextLine().split(" ");
        String[] secondLine = scanner.nextLine().split(" ");
        scanner.close();

        int numOfBankers = Integer.parseInt(firstLine[0]);
        int numOfParticipants = Integer.parseInt(secondLine[0]);

        String[] bankersPreferences = firstLine[1].split(",");
        String[] participantsPreferences = secondLine[1].split(",");

        int[][] bankersPreferencesArrOfArr = parsePreferences(bankersPreferences);
        int[][] participantsPreferencesArrOfArr = parsePreferences(participantsPreferences);


        int result = calculateMinimumSession(numOfBankers, numOfParticipants, bankersPreferencesArrOfArr, participantsPreferencesArrOfArr);
        // Please do not remove the below line.
        System.out.println(result);
        // Do not print anything after this line
    }

    private static int[][] parsePreferences(String[] preferences) {
        return Arrays.stream(preferences)
                .map(preference -> {
                    String[] preferenceArr = preference.split("&");
                    return Stream.of(preferenceArr).mapToInt(Integer::parseInt).toArray();
                })
                .toArray(int[][]::new);
    }
}
