namespace IaPluginPoc.Models;

public class Quote
{
    private Quote(PersonCustomer customer, string problemDescription)
    {
        PersonCustomer = customer;
        ProblemDescription = problemDescription;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string ProblemDescription { get; private set; }
    public Contact? Contact { get; private set; }
    public List<QuoteItem> QuoteItems { get; private set; } = [];
    public PersonCustomer? PersonCustomer { get; private set; }
    public OrganizationCustomer? OrganizationCustomer { get; private set; }
    public int TotalPrice { get; private set; }

    public static Quote CreateMinimalValidQuote()
    {
        var personCustomer = new PersonCustomer
        {
            Firstname = "Sébastien",
            Lastname = "Vandaele",
            Email = "s@vandaele.com",
            Phone = "+3598888888",
            Salutation = Salutation.Mr
        };
        return new Quote(personCustomer, """
                                            Le client souhaite refaire entièrement la salle de bain de son appartement. 
                                            Il désire remplacer la baignoire actuelle par une douche à l’italienne, avec un receveur extra-plat de 120x90 cm. 
                                            Il veut également poser un nouveau carrelage mural de type faïence blanche mate, format 30x60, jusqu’à une hauteur de 2 mètres sur les murs. 
                                            Le sol devra être recarrelé avec des carreaux imitation bois, de dimension 20x120 cm, avec un budget de 30 €/m² maximum. 
                                            Enfin, il demande l’installation d’un meuble vasque suspendu avec miroir et éclairage intégré.
                                         """);
    }

    public void LinkContact(Contact contact)
    {
        Contact = contact;
    }

    public void LinkOrganizationCustomer(OrganizationCustomer organizationCustomer)
    {
        OrganizationCustomer = organizationCustomer;
    }

    public void LinkPersonCustomer(PersonCustomer personCustomer)
    {
        PersonCustomer = personCustomer;
    }

    public void AddQuoteItem(QuoteItem quoteItem)
    {
        QuoteItems.Add(quoteItem);
        TotalPrice += quoteItem.Price;
    }

    public QuoteItem UpdateQuoteItem(Guid quoteItemId, Guid productId, string category, int quantity, int unitPrice)
    {
        var quoteItem = QuoteItems.Single(qi => qi.Id == quoteItemId);
        quoteItem.Update(productId, category, quantity, unitPrice);
        TotalPrice = QuoteItems.Sum(qi => qi.Price);
        return quoteItem;
    }
}