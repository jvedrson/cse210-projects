using System;

/*
===========================
Eternal Quest Program
===========================
Creativity / Exceeding Requirements:
  - Each goal has a unique auto-incremented ID, so the user can Delete
    or Edit goals by ID. The ID is stable across list re-orderings and
    deletions, and is shown alongside each goal in the listings.

*/
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}