#include <stdio.h>

const char continueChar = 'y';

typedef int bool;
#define true 1
#define false 0

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

    printf("Rolled a %i and a %i\n", rollOne, rollTwo);

    if (rollOne == rollTwo) {
        printf("Both dice were the same. You lose!\n");
        continueGame = false;
    } else {
        score = score + rollOne + rollTwo;
        printf("Both dice were different! Your score is now %i\n", score);
        printf("Continue playing? (Y/N) ");
        scanf(" %c", &userChoice);
        if (userChoice != continueChar) continueGame = false;
    }
}

int main() {
    srand((unsigned)time(NULL));
    while (continueGame) {
        playRound();
    }
   
   return 0;
}