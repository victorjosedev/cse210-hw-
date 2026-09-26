# W04 Team Activity: Foundation Programs Design
**Course:** CSE 210 - Programming with Classes  
**Assignment:** Foundation Programs Design (YouTube Videos & Online Ordering)

---

## Part 1: Foundation Program #1 – YouTube Videos (Demonstrating Abstraction)

### 1. Overview & Purpose
The purpose of this program is to track YouTube videos and the user comments left on them. It models product awareness tracking without needing an external API or user input. It demonstrates the principle of **Abstraction** by hiding the internal details of how comments and videos are stored, providing clean methods to query the video details, list comments, and count comments.

### 2. Classes and Responsibilities

#### A. `Comment` Class
* **Responsibility:** Holds information about an individual comment (the commenter's name and comment text).
* **Attributes (Private):**
  * `_commenterName : string` — The name of the user who made the comment.
  * `_commentText : string` — The text content of the comment.
* **Behaviors / Methods (Public):**
  * `Comment(string commenterName, string commentText)` — Constructor to initialize attributes.
  * `GetCommenterName() : string` — Returns the commenter's name.
  * `GetCommentText() : string` — Returns the comment's message.
  * `GetFormattedComment() : string` — Returns a formatted string (e.g., `"- [CommenterName]: CommentText"`).

#### B. `Video` Class
* **Responsibility:** Tracks video metadata (title, author, length) and maintains its collection of comments.
* **Attributes (Private):**
  * `_title : string` — The title of the video.
  * `_author : string` — The channel/creator who published the video.
  * `_lengthInSeconds : int` — Duration of the video in seconds.
  * `_comments : List<Comment>` — Collection of comments associated with this video.
* **Behaviors / Methods (Public):**
  * `Video(string title, string author, int lengthInSeconds)` — Constructor initializing metadata and creating an empty comments list.
  * `AddComment(Comment comment) : void` — Adds a new `Comment` object to `_comments`.
  * `GetNumberOfComments() : int` — Returns the total count of comments (`_comments.Count`).
  * `GetComments() : List<Comment>` — Returns the list of comments.
  * `DisplayVideoDetails() : void` — Formats and displays the video information, total comment count, and iterates through each comment.

#### C. `Program` Class
* **Responsibility:** Serves as the driver. Instantiates 3–4 videos, populates each with 3–4 comments, stores them in a list, and loops through them to display their details.

---

### 3. Class Diagram (UML)

```text
+-------------------------------------------------------------+
|                            Video                            |
+-------------------------------------------------------------+
| - _title : string                                           |
| - _author : string                                          |
| - _lengthInSeconds : int                                    |
| - _comments : List<Comment>                                 |
+-------------------------------------------------------------+
| + Video(title : string, author : string, length : int)      |
| + AddComment(comment : Comment) : void                      |
| + GetNumberOfComments() : int                               |
| + GetComments() : List<Comment>                             |
| + DisplayVideoDetails() : void                              |
+-------------------------------------------------------------+
                              |
                              | 1 contains *
                              v
+-------------------------------------------------------------+
|                           Comment                           |
+-------------------------------------------------------------+
| - _commenterName : string                                   |
| - _commentText : string                                     |
+-------------------------------------------------------------+
| + Comment(commenterName : string, commentText : string)     |
| + GetCommenterName() : string                               |
| + GetCommentText() : string                                 |
| + GetFormattedComment() : string                            |
+-------------------------------------------------------------+
```

### 4. Program Execution Flow
1. `Program.Main()` initializes a `List<Video>`.
2. Creates `Video` instances (e.g., Video 1, Video 2, Video 3).
3. For each video, creates 3–4 `Comment` instances and calls `video.AddComment(comment)`.
4. Loops through `videos`:
   * Prints Title, Author, Length (seconds).
   * Calls `video.GetNumberOfComments()` to display total comments.
   * Iterates through `video.GetComments()` and prints each commenter's name and message.

---

## Part 2: Foundation Program #2 – Online Ordering (Demonstrating Encapsulation)

### 1. Overview & Purpose
The purpose of this program is to manage an online ordering system that computes order totals, determines shipping fees based on customer location, and generates packing labels and shipping labels. It demonstrates **Encapsulation** by keeping all member variables private, delegating domain logic to the appropriate classes (e.g., address determines if it is in the USA, customer delegates to address, order computes totals), and preventing external tampering with prices or addresses.

### 2. Classes and Responsibilities

#### A. `Address` Class
* **Responsibility:** Stores physical address details and determines whether the location is within the USA.
* **Attributes (Private):**
  * `_streetAddress : string` — Street name and building number.
  * `_city : string` — City name.
  * `_stateProvince : string` — State, province, or region.
  * `_country : string` — Country name (e.g., "USA", "United States", "Mexico").
* **Behaviors / Methods (Public):**
  * `Address(string street, string city, string stateProvince, string country)` — Constructor.
  * `IsInUSA() : bool` — Returns `true` if `_country` is "USA" or "United States" (case-insensitive); otherwise `false`.
  * `GetFullAddress() : string` — Returns the address as a multi-line formatted string.

#### B. `Customer` Class
* **Responsibility:** Holds customer identification and their address.
* **Attributes (Private):**
  * `_name : string` — Full customer name.
  * `_address : Address` — An instance of the `Address` class.
* **Behaviors / Methods (Public):**
  * `Customer(string name, Address address)` — Constructor.
  * `LivesInUSA() : bool` — Calls and returns `_address.IsInUSA()`.
  * `GetName() : string` — Returns customer name.
  * `GetAddress() : Address` — Returns customer address object.

#### C. `Product` Class
* **Responsibility:** Represents a product being purchased, including pricing and quantity.
* **Attributes (Private):**
  * `_name : string` — Product name.
  * `_productId : string` — Unique SKU/ID.
  * `_price : decimal` — Price per unit.
  * `_quantity : int` — Quantity ordered.
* **Behaviors / Methods (Public):**
  * `Product(string name, string productId, decimal price, int quantity)` — Constructor.
  * `GetTotalCost() : decimal` — Calculates `_price * _quantity`.
  * `GetName() : string` — Returns product name.
  * `GetProductId() : string` — Returns product ID.

#### D. `Order` Class
* **Responsibility:** Aggregates a customer and a list of ordered products, computes overall costs with shipping fees, and generates packing/shipping labels.
* **Attributes (Private):**
  * `_products : List<Product>` — List of products in this order.
  * `_customer : Customer` — The customer placing the order.
* **Behaviors / Methods (Public):**
  * `Order(Customer customer)` — Constructor initializing customer and an empty product list.
  * `AddProduct(Product product) : void` — Appends a product to `_products`.
  * `CalculateTotalCost() : decimal` — Sums `product.GetTotalCost()` for all products + one-time shipping cost ($5 if customer lives in the USA, $35 otherwise).
  * `GetPackingLabel() : string` — Returns a string listing the name and ID of each product.
  * `GetShippingLabel() : string` — Returns a string containing customer name and formatted address.

#### E. `Program` Class
* **Responsibility:** Driver class. Creates at least two orders (one USA customer, one international customer), populates with 2–3 products each, and outputs their packing labels, shipping labels, and final total prices.

---

### 3. Class Diagram (UML)

```text
+-------------------------------------------------------------+
|                            Order                            |
+-------------------------------------------------------------+
| - _products : List<Product>                                 |
| - _customer : Customer                                      |
+-------------------------------------------------------------+
| + Order(customer : Customer)                                |
| + AddProduct(product : Product) : void                      |
| + CalculateTotalCost() : decimal                            |
| + GetPackingLabel() : string                                |
| + GetShippingLabel() : string                               |
+-------------------------------------------------------------+
          |                                      |
          | 1 has *                              | 1 belongs to 1
          v                                      v
+-------------------------------+      +-------------------------------+
|            Product            |      |           Customer            |
+-------------------------------+      +-------------------------------+
| - _name : string              |      | - _name : string              |
| - _productId : string         |      | - _address : Address          |
| - _price : decimal            |      +-------------------------------+
| - _quantity : int             |      | + Customer(name, address)     |
+-------------------------------+      | + LivesInUSA() : bool         |
| + Product(name, id, price, q) |      | + GetName() : string          |
| + GetTotalCost() : decimal    |      | + GetAddress() : Address      |
| + GetName() : string          |      +-------------------------------+
| + GetProductId() : string     |                      |
+-------------------------------+                      | 1 has 1
                                                       v
                                       +-------------------------------+
                                       |            Address            |
                                       +-------------------------------+
                                       | - _streetAddress : string     |
                                       | - _city : string              |
                                       | - _stateProvince : string     |
                                       | - _country : string           |
                                       +-------------------------------+
                                       | + Address(st, city, prov, c)  |
                                       | + IsInUSA() : bool            |
                                       | + GetFullAddress() : string   |
                                       +-------------------------------+
```

### 4. Program Execution Flow
1. Create `Address` instances (one USA, one non-USA).
2. Create `Customer` instances with those addresses.
3. Create `Order` instances for each customer.
4. Add 2–3 `Product` instances to each order.
5. For each order, display:
   * **Packing Label:** `order.GetPackingLabel()`
   * **Shipping Label:** `order.GetShippingLabel()`
   * **Total Cost:** `order.CalculateTotalCost()` (which internally uses customer location to add $5 or $35).
