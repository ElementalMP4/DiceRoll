#include <iostream>
#include <time.h>
#include <cctype>

using namespace std;

const char continueChar = 'y';

bool continueGame = true;
int score = 0;

int rollOne;
int rollTwo;

char userChoice;

int getRandomDiceRoll() {
    return 1 + (rand() % 6);
}

void playRound() {
    rollOne = getRandomDiceRoll();
    rollTwo = getRandomDiceRoll();

    cout << "Rolled a " << rollOne << " and a " << rollTwo << endl;

    if (rollOne == rollTwo) {
        cout << "Both dice were the same. You lose!" << endl;
        continueGame = false;
    } else {
        score = score + rollOne + rollTwo;
        cout << "Both dice were different! Your score is now " << score << endl;
        cout << "Continue playing? (Y/N) ";
        cin >> userChoice;
        if (tolower(userChoice) != continueChar) continueGame = false;
    }
}

int main() {
    srand((unsigned)time(NULL));
    while (continueGame) {
        playRound();
    }
    cout << "Your final score was " << score << endl;
    cin;
    return 0;
}