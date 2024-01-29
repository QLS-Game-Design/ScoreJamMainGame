// using UnityEngine;
// using LootLocker;
// using System;

// public class LeaderboardManager : MonoBehaviour
// {
//     public string leaderboardKey = "YourLeaderboardKey";
//     public int leaderboardID = 123;

//     // Get the leaderboard from the top
//     public void GetLeaderboardFromTop(int count)
//     {
//         LootLockerSDKManager.GetScoreList(leaderboardKey, count, 0, (response) =>
//         {
//             if (response.success)
//             {
//                 Debug.Log("Leaderboard fetched successfully");
//                 // Process leaderboard data here
//             }
//             else
//             {
//                 Debug.LogError("Failed to fetch leaderboard: " + response.Error);
//             }
//         });
//     }

//     // Submit a score to the leaderboard
//     public void SubmitScore(string memberID, int score)
//     {
//         LootLockerSDKManager.SubmitScore(memberID, score, leaderboardID, (response) =>
//         {
//             if (response.success)
//             {
//                 Debug.Log("Score submitted successfully");
//             }
//             else
//             {
//                 Debug.LogError("Failed to submit score: " + response.Error);
//             }
//         });
//     }

//     // Get a single entry on the leaderboard
//     public void GetSingleEntry(string memberID)
//     {
//         LootLockerSDKManager.GetMemberRank(leaderboardKey, memberID, (response) =>
//         {
//             if (response.success)
//             {
//                 Debug.Log("Single entry fetched successfully");
//                 // Process single entry data here
//             }
//             else
//             {
//                 Debug.LogError("Failed to fetch single entry: " + response.Error);
//             }
//         });
//     }

//     // Get specific scores for a list of members
//     public void GetScoresForMembers(string[] memberIDs)
//     {
//         LootLockerSDKManager.GetByListOfMembers(leaderboardKey, memberIDs, (response) =>
//         {
//             if (response.success)
//             {
//                 Debug.Log("Scores for members fetched successfully");
//                 // Process scores data here
//             }
//             else
//             {
//                 Debug.LogError("Failed to fetch scores for members: " + response.Error);
//             }
//         });
//     }
// }
