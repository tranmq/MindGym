# Problem:
Print the 2D matrix in the spiral form.
  
  ```
  Input:
  {
    {1,2,3,4},
    {8,7,6,5}
  }
  Output:
  1|2|3|4|5|6|7|8

  Input:
  {{1,2,3,4,5}}
  Output:
  1|2|3|4|5

  Input:
  {
    {1},
    {2},
    {3},
    {4},
    {5}
  }
  Output:
  1|2|3|4|5

  Input:
  {
    {1,  2,  3,  4,  5},
    {16, 17, 18, 19, 6},
    {15, 24, 25, 20, 7},
    {14, 23, 22, 21, 8},
    {13, 12, 11, 10, 9},
  }
  Output:
  1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25
  ```

# Solution:
* Iterate the matrix east, south, west, north starting from the first element of the first row (index[0,0]).
* When finished with 1 round, repeat with the "inner" matrix.  In order to keep track of rows and columns that have been visited, I use 4 variables top, right, bottom, left.  When finished iterating east, top is incremented by 1.  When finished iterating south, right is decremented.  When finish iterating west, bottom is decremented.  And lastly, when finish iterating north, left is incremented.
* We're done when the row and column crossed, that is, `left > right` or `top > bottom`.
