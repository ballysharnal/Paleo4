using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeVetement : MonoBehaviour {
    public TypeVetementEnum type;
}

public enum TypeVetementEnum {
    Tete,
    Cou, 
    Haut,
    BasPied, 
    Accessoire
}
