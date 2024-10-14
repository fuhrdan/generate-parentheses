//*****************************************************************************
//** 22. Generate Parentheses    leetcode                                    **
//*****************************************************************************


/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
void generateParenthesisRecu(char** result, int* returnSize, char* current, int left, int right, int n)
{
    if (left == 0 && right == 0)
    {
        result[*returnSize] = (char*)malloc((2 * n + 1) * sizeof(char));
        strcpy(result[*returnSize], current);
        (*returnSize)++;
        return;
    }

    if (left > 0)
    {
        int len = strlen(current);
        current[len] = '(';
        current[len + 1] = '\0';
        generateParenthesisRecu(result, returnSize, current, left - 1, right, n);
        current[len] = '\0'; // backtrack
    }

    if (left < right)
    {
        int len = strlen(current);
        current[len] = ')';
        current[len + 1] = '\0';
        generateParenthesisRecu(result, returnSize, current, left, right - 1, n);
        current[len] = '\0'; // backtrack
    }
}

char** generateParenthesis(int n, int* returnSize)
{
    *returnSize = 0;
    int maxSize = 1;
    for (int i = 1; i <= n; i++)
    {
        maxSize *= (2 * i); // Estimate upper bound size for result
    }
    
    char** result = (char**)malloc(maxSize * sizeof(char*));
    char* current = (char*)malloc((2 * n + 1) * sizeof(char)); // To hold the current string
    
    current[0] = '\0'; // Initialize the current string
    generateParenthesisRecu(result, returnSize, current, n, n, n);
    
    free(current); // Free the temporary string used for recursion
    return result;
}