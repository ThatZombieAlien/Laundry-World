﻿using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            if (database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"],
                (bool)itemData[i]["stackable"], itemData[i]["slug"].ToString(), (bool)itemData[i]["consumable"]));
        }
    }
}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public bool Stackable { get; set; }
    public string Slug { get; set; }
    public bool Consumable { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, int value, bool stackable, string slug, bool consumable)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Stackable = stackable;
        this.Slug = slug;
        this.Consumable = consumable;
        this.Sprite = Resources.Load<Sprite>(slug);
    }


    //Empty slot
    public Item()
    {
        this.ID = -1;
    }
}
