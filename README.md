# proportions-calculator

## Purpose

The purpose of this program is to solve the following problem:

- Given a list of $N$ items in **initial quantities**

    $$[ q_{1}, q_{2}, ... , q_{N} ],$$

  we wish to add the **least amounts possible** so that we end up with the **desired ratios**

    $$r_{1} : r_{2} : ... : r_{N}.$$

- How much do we need to add to each item to obtain the desired ratios?

### Real-world example

Suppose we are mixing metals to obtain a desired alloy, and we are given an existing alloy to start with. How much of each metal do we need to add in order to obtain the desired alloy?

Example:

- We start with 2g of gold, 4g of silver, and 5g of palladium (we represent this as `[2, 4, 5]`), and the desired ratio is `1:3:2` (which we represent as `[1, 3, 2]`, or equivalently as rounded percentages `[16.7, 50, 33.3]`)
- The smallest quantities that satisfy the desired ratio AND are at least as large as the existing quantities `[2, 4, 5]` (since we can't remove metals from an alloy easily) are **`[2.5, 7.5, 5]`**.
- Thus, we need to add the following amounts to achieve our desired alloy: `[0.5, 3.5, 0]`, i.e. **0.5g of gold, and 3.5g of silver**.

## How to use

To use this program, you need to follow these steps:

1. Download a ZIP file from the `builds` folder of this repository.

2. Extract the contents of the ZIP file. You will get a directory containing `ProportionsCalculator.dll` and some other files.

3. Edit a file called `input.json` in the same directory, and fill it out in the following format:

    ```json
    {
        "InitialQuantities": [2, 4, 5],
        "DesiredProportions": [1, 3, 2]
    }
    ```

    - You can have as many elements in your lists as you like (as long as both lists have the same number of elements).
    - You can use decimals in your lists.

4. Open PowerShell and navigate to the directory above, for example using

    ```powershell
    cd 'C:\Users\stefan\Downloads\ProportionsCalculator v1.0.0'
    ```

5. Run

   ```powershell
   dotnet ProportionsCalculator.dll
   ```

## Mathematical proof

This section explains the mathematics of how to solve the general problem.

We know that any solution has to be a multiple of the desired ratios, i.e.

$$m[r_{1}, r_{2}, ... , r_{N}] = [mr_{1}, mr_{2}, ... , mr_{N}]$$

for some multiplier $m$.

To get the ideal solution (the one where we add the least amounts possible), we simply need to find the smallest value of $m$ such that each quantity in the solution is at least as large as its initial value, i.e.

$$mr_{i} \geq q_{i}$$

for all values of $i$ (because we cannot reduce quantities).

The value of $m$ is therefore

$$m = \max_{1 \leq i \leq N} \left( \dfrac{q_{i}}{r_{i}} \right).$$

Note that we will always get at least one item that doesn't need to change quantity - the one that gives us the value of $m$.