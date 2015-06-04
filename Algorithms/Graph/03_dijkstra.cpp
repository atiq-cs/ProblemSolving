/*
For now, refer to: online-problem-solving\spoj\SPOJ_TRVCOST.cpp
A generic implementation deomonstration will be added lter

Issues to fix:
    A use of map implementation instead of 2d array for maintaining cost which will be useful for 
    sparse graphs

    ** there are a number of redundant operations in code
    Two vectors had been initialized with provided size
    Then they have been cleared
        vertex.clear();
        adj_list.clear();
    Afterwards, they have been pushed again
    Though it saves from memory reallocation overhead.
    However, these are sort of redundant operations

    BFS implementation will avoid them
*/