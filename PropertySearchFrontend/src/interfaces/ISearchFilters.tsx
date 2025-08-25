export interface SearchFilters {
    type?: string;
    minPrice?: number;
    maxPrice?: number;
    query?: string;
    page?: number;
    sort?: "price" | "title";
  }