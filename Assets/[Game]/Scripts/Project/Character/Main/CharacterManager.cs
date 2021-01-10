using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    #region Character Type Properties
    private List<Character> characters;
    public List<Character> Characters { get { return (characters == null) ? characters = new List<Character>() : characters; } set { characters = value; } }

    private Character player;

    public Character Player
    {
        get
        {
            if (player == null)
            {
                foreach (var character in Characters)
                {
                    if (character.CharacterControllerType == CharacterControllerType.Player)
                        player = character;
                }
            }

            return player;
        }

        set
        {
            player = value;
        }
    }

    private List<Character> aiCharacters;
    public List<Character> AICharacters
    {
        get
        {
            if (aiCharacters == null || aiCharacters.Count == 0)
            {
                foreach (var character in Characters)
                {
                    if (character.CharacterControllerType == CharacterControllerType.AI)
                    {
                        if (!aiCharacters.Contains(character))
                            aiCharacters.Add(character);
                        Debug.Log(aiCharacters.Count);
                    }
                }
            }

            return aiCharacters;
        }

        set
        {
            aiCharacters = value;
            Debug.Log(aiCharacters.Count);
        }
    }
    #endregion

    #region Public Methods
    public void AddCharacter(Character character)
    {
        if (!Characters.Contains(character))
            Characters.Add(character);
    }

    public void RemoveCharacter(Character character)
    {
        if (Characters.Contains(character))
            Characters.Remove(character);
    }

    public void setEnabled(Character character, Transform transform)
    {
        character.transform.position = transform.position;
        character.enabled = true;
    }

    public void Initiliaze()
    {
        foreach (var character in characters)
        {
            character.enabled = false;
        }
    }
    #endregion
}