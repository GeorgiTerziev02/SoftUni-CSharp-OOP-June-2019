using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private string heroName = "AAA";
    private int heroLevel = 5;
    private HeroRepository repository;

    [SetUp]
    public void StartUp()
    {
        this.hero = new Hero(heroName, heroLevel);
        this.repository = new HeroRepository();
    }

    [Test]
    public void TestIfHeroConstructorWorksCorrectly()
    {
        Assert.AreEqual(heroName, this.hero.Name);
        Assert.AreEqual(heroLevel, this.hero.Level);
    }

    [Test]
    public void TestIfRepositoryConstructorWorksCorrectly()
    {
        Assert.IsNotNull(this.repository.Heroes);
    }

    [Test]
    public void TestIfCreateHeroWorksCorrectly()
    {
        int expectedCount = 1;
        string expectedOutput = $"Successfully added hero {this.hero.Name} with level {this.hero.Level}";

        string actualResult = this.repository.Create(this.hero);

        Assert.AreEqual(expectedCount, this.repository.Heroes.Count);
        Assert.AreEqual(expectedOutput, actualResult);
    }

    [Test]
    public void TestCreateHeroWithNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.repository.Create(null);
        }, "Hero is null");
    }

    [Test]
    public void TestCreateHeroWithAlreadyAddedHero()
    {
        this.repository.Create(this.hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            this.repository.Create(this.hero);
        }, $"Hero with name {hero.Name} already exists");
    }

    [Test]
    public void TestIfRemoveMethodWorksCorrectlyAndReturnsTrue()
    {
        this.repository.Create(this.hero);

        bool result = this.repository.Remove(this.heroName);

        Assert.IsTrue(result);
    }

    [Test]
    public void TestRemoveReturnsFalse()
    {
        this.repository.Create(this.hero);

        bool result = this.repository.Remove("PPP");

        Assert.IsFalse(result);
    }

    [Test]
    public void TestRemoveWithNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.repository.Remove(null);
        }, "Name cannot be null");
    }

    [Test]
    public void TestRemoveWithWhiteSpace()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.repository.Remove("   ");
        }, "Name cannot be null");
    }

    [Test]
    public void TestIfGetHeroWorksCorrectly()
    {
        this.repository.Create(this.hero);

        Hero result = this.repository.GetHero(this.heroName);

        Assert.AreEqual(this.hero, result);
    }

    [Test]
    public void TestGetHeroReturnNull()
    {
        Hero result = this.repository.GetHero("PPP");

        Assert.IsNull(result);
    }

    [Test]
    public void TestIfGetHighestRatedHeroWorksCorrectly()
    {
        this.repository.Create(this.hero);
        Hero firstHero = new Hero("Gosho", 34);
        Hero secondHero = new Hero("Pesho", 24);

        this.repository.Create(firstHero);
        this.repository.Create(secondHero);

        Hero result = this.repository.GetHeroWithHighestLevel();

        Assert.AreEqual(firstHero, result);
    }
}