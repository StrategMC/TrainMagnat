using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasearchData : MonoBehaviour
{
    int point;
    List<SteamEngine> engines;
    List<MechShasi> mechs;
    List<EkoSpace> space;
    List<OptimizationEngine> optimizationEngines;
    List<KonstructEngine> konstructEngines;
    List<KonstructShasi> konstructShasis;

}
struct SteamEngine
{
    string Name;
    int cost;
    int bonus;
    int year;
}
struct MechShasi
{
    string Name;
    int cost;
    int bonus;
    int year;
}
struct EkoSpace
{
    string Name;
    int cost;
    int bonus;
    int year;
}
struct OptimizationEngine
{
    string Name;
    int cost;
    int bonus;
    int year;
}
struct KonstructEngine
{
    string Name;
    int cost;
    int bonus;
    int minus_bonus;
    int year;
}
struct KonstructShasi
{
    string Name;
    int cost;
    int bonus;
    int minus_bonus;
    int year;
}