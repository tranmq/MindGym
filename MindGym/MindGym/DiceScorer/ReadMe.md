# Dice Scorer

You have five eight-sided dice, and based on your roll, you can get a certain score as outlined below. Given a five-item array of integers (which represent the values rolled), return the highest possible score. 
  
* Ones – scores the sum of all the ones 
* Twos – scores the sum of all the twos 
* Threes – scores the sum of all the threes 
* Fours – scores the sum of all the fours 
* Fives – scores the sum of all the fives 
* Sixes – scores the sum of all the sixes 
* Sevens – scores the sum of all the sevens 
* Eights – scores the sum of all the eights 
* ThreeOfAKind – scores the sum of all dice if there are 3 or more of the same die, otherwise scores 0 
* FourOfAKind – scores the sum of all dice if there are 4 or more of the same die, otherwise scores 0 
* AllOfAKind – Scores 50 if all of the dice are the same, otherwise scores 0 
* NoneOfAKind – Scores 40 if there are no duplicate dice, otherwise scores 0 
* FullHouse – Scores 25 if there are two duplicate dice of one value and three duplicate dice of a different value, otherwise scores 0 
* SmallStraight – Scores 30 if there are 4 or more dice in a sequence, otherwise scores 0 
* LargeStraight – Scores 40 if all 5 dice are in a sequence, otherwise scores 0 
* Chance – scores the sum of all dice 

____________________


For example, if you roll the following: `1, 1, 1, 4, 8` 


This roll will match the following rules and corresponding scores: 
* Ones – score of 3 
* Fours – score of 4 
* Eights – score of 8 
* Chance – score of 15 
* ThreeOfAKind – score of 15 
  

So you would return 15 since that’s the highest possible score.
