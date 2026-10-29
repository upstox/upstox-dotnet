# US Stocks API – Example code

Links to all US Stocks examples in the `code/` folder.

> **Note:** The US Stocks APIs are currently available only on UAT (`https://uat-api.upstox.com`).
> To try them there, point the SDK at UAT:
> `options.AddApiHttpClients(client => client.BaseAddress = new Uri("https://uat-api.upstox.com"));`

## 1. Orders

- 1.1 [Place US order by quantity](code/place-order.md#place-us-order-by-quantity)
- 1.2 [Place US order by amount](code/place-order.md#place-us-order-by-amount)
- 1.3 [Modify US order](code/modify-order.md#modify-us-order)
- 1.4 [Cancel US order](code/cancel-order.md#cancel-us-order)
- 1.5 [Get US order book](code/get-order-book.md#get-us-order-book)
- 1.6 [Get US order details](code/get-order-details.md#get-us-order-details)
- 1.7 [Get US order estimate](code/order-estimate.md#get-us-order-estimate)

## 2. Charges

- 2.1 [Get US margin](code/margin.md#get-us-margin)

## 3. Portfolio and Funds

- 3.1 [Get US holdings](code/get-holdings.md#get-us-holdings)
- 3.2 [Get US funds](code/get-funds.md#get-us-funds)

## 4. Market Holidays and Timings

- 4.1 [Get US market holidays](code/market-holidays-and-timings.md#get-us-market-holidays)
- 4.2 [Get US market holiday for a date](code/market-holidays-and-timings.md#get-us-market-holiday-for-a-date)
- 4.3 [Get US market timings](code/market-holidays-and-timings.md#get-us-market-timings)
- 4.4 [Get US market status](code/market-holidays-and-timings.md#get-us-market-status)
